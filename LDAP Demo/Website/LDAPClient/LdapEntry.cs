/* ***********************
 * Adapted from:
 * https://github.com/auth0-blog/blog-ldap-csharp-example
 * Related Article:
 * https://auth0.com/blog/using-ldap-with-c-sharp/
 */
using System.Collections.Generic;

namespace LDAPClient
{
    public class LdapEntry
    {
        public string DistinguishedName { get; internal set; }
        public List<LdapAttribute> Attributes { get; internal set; }
    }
}
