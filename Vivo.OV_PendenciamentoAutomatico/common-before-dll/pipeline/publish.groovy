steps.echo "publish.groovy"



def config = devops.getConfig({ steps })
VERSION_CURRENT = config.version.current


def setCompStatus() {

  // Salva versão do componente publicada no Nexus
  def psScript = "${GIT_SCRIPTS_DIR}\\setCompStatus.ps1"
  def ObjectName = "${ARTIFACT_ID}"
  
  //Indra:    fabrID=1
  //E2E:      fabrID=2
  //VP RH:    fabrID=3
  //VP ENG:   fabrID=4
  //INTERNO:  fabrID=5
  def fabrID = 2
  
  def ObjectVersion = versionCurrent
  def toolName = "rpa-bp-script-setCompStatus"

  // Executa comando
  def psOutput
  try {
    steps.echo "Running ${powershellTool} ..."
    psOutput = steps.bat(returnStdout: true, script: """
      \"${powershellTool}\" \"${psScript}\" -ObjectName '${ObjectName}' -fabrID ${fabrID} -ObjectVersion \"${ObjectVersion}\"
    """)
  }
  catch(Exception e) {
    steps.echo "Exception: ${e.message}"
    //Erro parar processo caso continueOnError = false
  }

  // Exibe output
  steps.echo "${psOutput}"

  //publishLog text: psOutput,
  //  toolName: toolName
}

try{
  def nupkg = "${ARTIFACT_ID}.${VERSION_CURRENT}.nupkg"

  nugetPublish steps: steps,
    artifactId: ARTIFACT_ID,
    version: VERSION_CURRENT,
    nupkg: nupkg

}catch (Exception){}
  

powershellTool = steps.tool name: "powershell-${POWERSHELL_VERSION}"
versionCurrent = config.version.current
setCompStatus()
