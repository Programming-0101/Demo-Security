/* ***********************
 * Adapted from:
 * https://github.com/auth0-blog/blog-ldap-csharp-example
 * Related Article:
 * https://auth0.com/blog/using-ldap-with-c-sharp/
 */
using System;
using System.Collections.Generic;
using System.DirectoryServices.Protocols; // Add Reference
using System.Net;

namespace LDAPClient
{
    /// <summary>
    /// A sample LDAP client. For simplicity reasons, this clients only uses synchronous requests.
    /// </summary>
    public class Client
    {
        private readonly LdapConnection connection;

        public Client(string username, string password, string url, string domain = null)
        {
            connection = new LdapConnection(url);
            connection.Timeout = new TimeSpan(0, 0, 10);
            connection.AuthType = AuthType.Basic;
            connection.SessionOptions.ProtocolVersion = 3; // Set protocol to LDAPv3

            var credentials = new NetworkCredential(username, password);

            connection.Bind(credentials);
        }

        /// <summary>
        /// Performs a search in the LDAP server. This method is generic in its return value to show the power
        /// of searches. A less generic search method could be implemented to only search for users, for instance.
        /// </summary>
        /// <param name="baseDn">The distinguished name of the base node at which to start the search</param>
        /// <param name="ldapFilter">An LDAP filter as defined by RFC4515</param>
        /// <returns>A flat list of dictionaries which in turn include attributes and the distinguished name (DN)</returns>
        public SearchResponse Search(string searchDn, string ldapFilter = "objectClass=*")
        {
            var request = new SearchRequest(searchDn, ldapFilter, SearchScope.Subtree, null);
            var response = (SearchResponse)connection.SendRequest(request);
            List<LdapEntry> entries = new List<LdapEntry>();
            return response;
        }
    }
}
