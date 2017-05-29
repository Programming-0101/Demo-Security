# Programming 0101 Training Resources

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

## Repositories

- Programming Fundamentals
  - **TheBook** - 
  - **TheCode** - 
- ASP.NET Identity
  - 
