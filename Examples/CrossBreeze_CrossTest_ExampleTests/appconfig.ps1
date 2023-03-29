$currentDirectory = [IO.Path]::GetDirectoryName($MyInvocation.MyCommand.Path)

$appConfigFile = [IO.Path]::Combine($currentDirectory, 'App.config')

$appConfig = New-Object XML

$appConfig.Load($appConfigFile)

foreach($BuildNumber in $appConfig.configuration.add)
{
    'name: ' + $BuildNumber.name
    'BuildNumber: ' + $BuildNumber.value
    $BuildNumber.value = '123456789'
}
$appConfig.Save($appConfigFile)