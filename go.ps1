[CmdletBinding()]
param ([string]$branch)

function RunGit($params)
{
    Write-Verbose "git $params"
    $process = Start-Process git -ArgumentList $params -NoNewWindow -PassThru -Wait
    $process.ExitCode
}

$exitCode = RunGit "show-ref --verify -q refs/heads/$branch"

if ($exitCode -eq 0)
{
    #Write-Verbose "git checkout $branch"
    #git checkout $branch
    $exitCode = RunGit "checkout $branch --quiet"
}
else
{
    Write-Verbose "git checkout -b $branch"
    git checkout -b $branch
}

$path = "config\$branch"

if (Test-Path $path)
{
    $path = Join-Path $path *.*
    $files = Get-ChildItem $path
    $files | ForEach-Object { Copy-Item $_.PSPath . -Force }
    $files | ForEach-Object { git update-index --assume-unchanged $_.Name }
    $files | ForEach-Object { Write-Verbose "git update-index --assume-unchanged $($_.Name)" }
}
