steps.echo "build.groovy"

// cmd: msbuild
// solution: $MSBUILD_SOLUTION
// target: $MSBUILD_TARGET
// additional arguments: $MSBUILD_ADDITIONAL_ARGS

msbuildCompile steps: steps
