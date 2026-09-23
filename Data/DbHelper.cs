using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace MuhasebeOtomasyonu.Data
{
    public static class DbHelper
    {
        private static string? _cachedConnectionString;
        private static readonly object _lockObj = new object();

        private static string GetConnectionString()
        {
            if (!string.IsNullOrEmpty(_cachedConnectionString))
            {
                return _cachedConnectionString;
            }

            lock (_lockObj)
            {
                if (!string.IsNullOrEmpty(_cachedConnectionString))
                {
                    return _cachedConnectionString;
                }

                string? configuredConnStr = null;
                try
                {
                    configuredConnStr = ConfigurationManager.ConnectionStrings["MuhasebeDB"]?.ConnectionString
                            ?? ConfigurationManager.ConnectionStrings["MuhasebeConnection"]?.ConnectionString;
                }
                catch
                {
                }

                var candidates = new List<string>
                {
                    @"Server=localhost\SQLEXPRESS;Database=MuhasebeDB;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;"
                };
                foreach (var connStr in candidates)
                {
                    try
                    {
                        using (var conn = new SqlConnection(connStr))
                        {
                            conn.Open();
                            _cachedConnectionString = connStr;
                            return connStr;
                        }
                    }
                    catch
                    {
                        // Bir sonraki alternatifi dene
                    }
                }

                _cachedConnectionString = configuredConnStr ?? candidates[0];
                return _cachedConnectionString;
            }
        }

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(GetConnectionString());
        }

        public static bool TestConnection(out string errorMessage)
        {
            try
            {
                using (var conn = GetConnection())
                {
                    conn.Open();
                    errorMessage = string.Empty;
                    return true;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return false;
            }
        }
    }
}