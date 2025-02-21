## EF Core Sample App
This is a minimal EF Core sample application built to show an issue with efbundle.

If a project has enabled TreatWarningsAsErrors, NugetAuditMode is all, and is using
the SQL Server with efcore (`Microsoft.EntityFrameworkCore.SqlServer`) then `dotnet ef migrations bundle` will fail.

Adding verbose to the command reveals that the Warning is about a the package `System.Private.Uri`.

This is an example output from runing the bundle command with `--verbose`
```
Building bundle...
dotnet publish --runtime ubuntu.24.10-x64 --output /tmp/4bdomrr0.dao/publish --no-self-contained --disable-build-servers
  Determining projects to restore...
/..../efcore/src/efcore.csproj : error NU1903: Warning As Error: Package 'System.Private.Uri' 4.3.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-5f2m-466j-3848 [/tmp/4bdomrr0.dao/efbundle.csproj]
/..../efcore/src/efcore.csproj : error NU1902: Warning As Error: Package 'System.Private.Uri' 4.3.0 has a known moderate severity vulnerability, https://github.com/advisories/GHSA-x5qj-9vmx-7g6g [/tmp/4bdomrr0.dao/efbundle.csproj]
/..../efcore/src/efcore.csproj : error NU1903: Warning As Error: Package 'System.Private.Uri' 4.3.0 has a known high severity vulnerability, https://github.com/advisories/GHSA-xhfc-gr8f-ffwc [/tmp/4bdomrr0.dao/efbundle.csproj]
  Failed to restore /..../efcore/src/efcore.csproj (in 322 ms).
  Restored /tmp/4bdomrr0.dao/efbundle.csproj (in 511 ms).

```

The problem seems to be related to the `Microsoft.EntityFramework.SqlServer` nuget package, as it does not happen if we
use Sqlite (`Microsoft.EntityFrameworkCore.Sqlite`) instead of SqlServer
