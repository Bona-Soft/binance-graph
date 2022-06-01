# USAGE:
#
# Adds a new migration ("dotnet-ef migrations add --help"):
# .\Migrations.ps1 -environment DEVELOPMENT -action add MigrationName
#
# Updates the database to a specified migration ("dotnet-ef database update --help"):
# .\Migrations.ps1 -environment DEVELOPMENT -action update
#
# Removes the last migration ("dotnet-ef migrations remove --help"):
# .\Migrations.ps1 -environment TEST -action remove
#
# Generates a SQL script from migrations (dotnet-ef migrations script --help):
# .\Migrations.ps1 -environment STAGE -action script
#
# Lists available migrations ("dotnet-ef migrations list --help")
# .\Migrations.ps1 -environment PRODUCTION -action list

[CmdletBinding()]
Param(
    [Parameter(Mandatory=$true, Position=0)]
    [ValidateSet("DEVELOPMENT", "TEST", "STAGE", "PRODUCTION")]
    [string]$environment,

    [Parameter(Mandatory=$true, Position=1)]
    [string]$databaseProject,

    [Parameter(Mandatory=$true, Position=2)]
    [string]$apiProject,

    [Parameter(Mandatory=$true, Position=3)]
    [ValidateSet("add", "update", "remove", "script", "list")]
    [string]$action,

    [Parameter(Mandatory=$false, Position=4, ValueFromRemainingArguments=$true)]
    [psobject[]]$remaining
)

[Environment]::SetEnvironmentVariable("ZENFOLIO_ENVIRONMENT", $environment, "Process")
[Environment]::SetEnvironmentVariable("ZENFOLIO_BASE_PATH", $apiProject, "Process")

switch ($action) {
    "add" {
        dotnet-ef migrations add -s "$databaseProject" -p "$databaseProject" -v --no-build @remaining
        break
    }
    "update" {
        dotnet-ef database update -s "$databaseProject" -p "$databaseProject" -v --no-build @remaining
        break
    }
    "remove" {
        dotnet-ef migrations remove -s "$databaseProject" -p "$databaseProject" -v --no-build @remaining
        break
    }
    "script" {
        dotnet-ef migrations script -s "$databaseProject" -p "$databaseProject" -v --no-build @remaining
        break
    }
    "list" {
        dotnet-ef migrations list -s "$databaseProject" -p "$databaseProject" -v --no-build @remaining
        break
    }
}