param(
    [Alias("S")]
    [string]$Solution = "TaskManager.slnx",

    [Alias("C")]
    [string]$Configuration = "Debug",

    [Alias("LF")]
    [string]$LogFile = "build.log",
    
    [ValidateSet("min", "norm", "diag")]
    [Alias("V")]
    [string]$Verbosity = "min"
)

$ErrorActionPreference = "Continue"

$repoRoot = Split-Path -Parent $MyInvocation.MyCommand.Path
if (-not $env:DOTNET_CLI_HOME) {
    $env:DOTNET_CLI_HOME = Join-Path $repoRoot ".dotnet"
}
if (-not $env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE) {
    $env:DOTNET_SKIP_FIRST_TIME_EXPERIENCE = "1"
}
New-Item -ItemType Directory -Force -Path $env:DOTNET_CLI_HOME | Out-Null

[Console]::OutputEncoding = [System.Text.UTF8Encoding]::new($false)
$OutputEncoding = [Console]::OutputEncoding

$verbosityMap = @{
    min = "minimal"
    norm = "normal"
    diag = "diagnostic"
}
$msbuildVerbosity = $verbosityMap[$Verbosity]

$buildOutput = dotnet build $Solution `
    -c $Configuration `
    -m:1 `
    -v:$msbuildVerbosity 2>&1 | Out-String

Set-Content -Path $LogFile -Value $buildOutput -Encoding utf8

if ($LASTEXITCODE -ne 0) {
    Write-Error "Build failed. See $LogFile"
}

Write-Host "Build succeeded. Verbosity: $Verbosity. Log: $LogFile"
