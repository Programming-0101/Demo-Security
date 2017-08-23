# Programming 0101 Training Resources

## Database Encryption

The **Database Encryption** demo solution shows a simple SQL Column-Level encryption table that is inserted into and deleted from using EF6 and stored procedure calls.

Before running this solution, set up a database using the `Database Setup.sql` script file.

Credits/Resources:

- [SQL Server Column Level Encryption Example using Symmetric Keys](https://www.mssqltips.com/sqlservertip/2431/sql-server-column-level-encryption-example-using-symmetric-keys/)
- http://www.dotnetpiper.com/2015/01/database-table-encryption-using.html?m=1
- [Sql Server Encryption Tips](https://www.mssqltips.com/sql-server-tip-category/68/encryption-/)
- [SO Comment](https://stackoverflow.com/a/24317739/2154662) about having the `OPEN SYMMETRIC KEY...` happen in the same transaction as the SQL to encrypt/decrypt the data. In my sample solution, I simply include multiple SQL commands in a single string, so no need to be explicit about setting up a transaction scope.
- [SO Post](https://stackoverflow.com/a/9401807/2154662) noting three general encryption approaches:
  - **Transparent Data Encryption** - Feature of SQL Server - whole database is encrypted on SQL Server side. Your application doesn't need to change and it should work with EF.
  - **Cell level encryption** - feature of SQL Server - selected columns are encrypted and stored as `varbinary`. This requires special query and store commands so you will have to use specialized database views and stored procedures to interact with your DB if you want to use EF. If you don't want to use database views and stored procedures you will have to maintain EDMX manually and write all those SQL commands into its SSDL part.
  - **Encryption performed in your application** - you will use `ObjectMaterialized` and `SavingChanges` events to handle decryption and encryption yourselves. You will probably be able to encrypt and decrypt only string or binary data because your property data type must not change (in case of string you will have to store encrypted value as base64 string).
- [SQL SERVER – Introduction to SQL Server Encryption and Symmetric Key Encryption Tutorial with Script](https://blog.sqlauthority.com/2009/04/28/sql-server-introduction-to-sql-server-encryption-and-symmetric-key-encryption-tutorial-with-script/)
- Yet another [SO Post](https://stackoverflow.com/a/24632752/2154662) pointing to two helpful articles:
  - [How to use SQL Server Encryption with Symmetric Keys](http://benjii.me/2010/05/how-to-use-sql-server-encryption-with-symmetric-keys/)
  - [Decrypting Data](http://msdn.microsoft.com/en-us/library/te15te69%28v=vs.110%29.aspx?cs-save-lang=1&cs-lang=csharp#code-snippet-1) **in .NET**.
- [Encrypting SQL Server: Using an Encryption Hierarchy to Protect Column Data](https://www.red-gate.com/simple-talk/sql/sql-development/encrypting-sql-server-using-encryption-hierarchy-protect-column-data/) - **Has a nice image showing the encryption hierarchy**
- [CipherDb](https://www.crypteron.com/cipherdb/) - **3rd-Party Service** - see also this [SO reply](https://stackoverflow.com/a/42916385/2154662)
- [GitHub Gist](https://gist.github.com/albertbori/e95860644e69c1572441) showing a nice approach that somewhat mirrors what *CipherDb* does (above) by allowing entities to have an `[Encrypted]` attribute on various properties. Note however that this encryption occurs in the *application*, rather than being done by the database server.
- [Encrypt a Column of Data](https://docs.microsoft.com/en-us/sql/relational-databases/security/encryption/encrypt-a-column-of-data) (and on [TechNet](https://technet.microsoft.com/en-us/library/ms179331%28v=sql.110%29.aspx?f=255&MSPPError=-2147217396))
- [SQL Server Encryption Options](http://sqlmag.com/database-security/sql-server-encryption-options)
- [Column Level Encryption in SQL Server](http://www.databasejournal.com/features/mssql/article.php/3922881/Column-Level-Encryption-in-SQL-Server.htm)
- [EF6 Insert, Update, and Delete Stored Procedure](https://msdn.microsoft.com/en-us/library/dn468673%28v=vs.113%29.aspx?f=255&MSPPError=-2147217396)

## LOGs

At the end of this topic, you should be able to:

### Visual Studio 2017 Tooling

> Assumes a basic introduction to Visual Studio (2012 or higher) as an *Integrated Development Environment* (IDE) and to *Debugging* in Visual Studio.

- Use the *Object Browser* to discover and explore classes in a solution, project, and/or class library.
- Use the *Class View* to explor the active classes and other data types used in a VS solution.
- Perform intermediate debugging using the *Immediate Window*, *Call Stack*, and *Watch* windows

### Web Application Security

- Security Options:
  - Forms Authentication
  - Windows Authentication

### Entity Framework

**Resources:**

- [EntityFramework Tutorial](http://www.entityframeworktutorial.net/)


### Security Basics of ASP.Net Identity 2 (EF6)

The focus is on coding with Identity 2.0 with Entity Framework 6.

> Assumes a basic understanding of a client-server layered architecture that distinguishes between the *Presentation Layer* (PL), *Business Logic Layer* (BLL), *Data Access Layer* (DAL), and *Entities* (or Data Models).

**Core ASP.Net Identity Classes (EF6)**

- Associate the core Identity classes with the standard client-server layers (BLL, DAL, and Entities)
  - **BLL**
    - `UserManager<TUser>` (which inherits from `UserManager<TUser, TKey>`)
    - `RoleManager<TRole>` (which inherits from `RoleManager<TRole, TKey>`)
  - **DAL**
    - `IdentityDbContext<TUser>`
  - **Entities**
    - `IdentityUser` (which inherits from `IdentityUser<TKey, TLogin, TRole, TClaim>`)
    - `IdentityRole` (which inherits from `IdentityRole<String, IdentityUserRole>`)
    - `UserStore<TUser>` (which inherits from `UserStore<TUser, TRole, TKey, TUserLogin, TUserRole, TUserClaim>`)
      - *EntityFramework based user store implementation that supports IUserStore, IUserLoginStore, IUserClaimStore and IUserRoleStore*
- Explain the purpose of the `ApplicationUser` class
- List the core properties of the `IdentityUser` class
  - **Id**, **UserName**, **Email**, EmailConfirmed, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, Logins, **Roles**, Claims, SecurityStamp, PasswordHash, AccessFailedCount, LockoutEnabled, LockoutEndDateUtc
- Explain the purpose of the `ApplicationDbContext` class
- Explain the purpose of the `ApplicationUserManager` class
- Explain the purpose of the `UserStore<TUser>` class
- Explain the purpose of the `RoleManager<TRole>` class
- Customize the `ApplicationUser` class with additional properties
  - eg: `OfficeLocation`, `PhoneExtension`, `JobTitle`
- Create custom classes to implement `RoleManager<TRole>` and `UserStore<TUser>`
- Customize the `ApplicationUserManager` to perform 
- Customize the `ApplicationDbContext` class to use application configuration data in seeding the database with a default administrator account.

**Typical Web Forms for Security Management**


**Using ASP.Identity to Secure Website Access**

- Determine when the user is authenticated
- Determine the identity of the user
- restrict access to specific roles programmatically
- Use Authentication and Authorization attributes to restrict access
- Employ a configuration approach (web.config) to restrict access

**OWIN Fundamentals**


**Integrating Web Forms Authentication with Active Directory**

- Define the term ADFS (Active Directory Federated Services)

**Resources**

- [Channel 9 - Customizing ASP.NET Authentication with Identity](https://channel9.msdn.com/Series/Customizing-ASPNET-Authentication-with-Identity)
- [Configuring Chrome and Firefox for Windows Integrated Authentication](https://specopssoft.com/configuring-chrome-and-firefox-for-windows-integrated-authentication/)
- [How to Configure the Server to be Trusted for Delegation](https://docs.microsoft.com/en-us/microsoft-desktop-optimization-pack/appv-v4/how-to-configure-the-server-to-be-trusted-for-delegation)
- [Credentials Processes in Windows Authentication](https://docs.microsoft.com/en-us/windows-server/security/windows-authentication/credentials-processes-in-windows-authentication)
- [Group Policy Settings Used in Windows Authentication](https://docs.microsoft.com/en-us/windows-server/security/windows-authentication/group-policy-settings-used-in-windows-authentication)

## Repositories

- Programming Fundamentals
  - **TheBook** - 
  - **TheCode** - 
- ASP.NET Identity
  - 
