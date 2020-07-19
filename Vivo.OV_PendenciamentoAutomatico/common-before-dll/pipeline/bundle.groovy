steps.echo "bundle.groovy"

// Version
def config = devops.getConfig({ steps })
VERSION_CURRENT = config.version.current

// Nuget
// cmd: nuget pack
// nuspec: $NUGET_NUSPEC
// additional arguments: $NUGET_PACKAGE_ADDITIONAL_ARGS
nugetPackage steps: steps,
  version: VERSION_CURRENT
