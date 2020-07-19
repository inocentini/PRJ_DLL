steps.echo "deps.groovy"

// Obtém repositório de scripts
gitClone steps: this,
  url: GIT_SCRIPTS_REPOSITORY,
  username: GIT_CREDENTIAL_USR,
  password: GIT_CREDENTIAL_PSW,
  folder: GIT_SCRIPTS_DIR,
  branch: GIT_SCRIPTS_REPOSITORY_BRANCH

  
nugetDependenciesDownload steps: steps
