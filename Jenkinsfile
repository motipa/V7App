pipeline {
    agent any

    stages {
        stage('clean') {
            steps {
                ech 'clean App'
              cleanWs()
                  }
                  }
                   stage('checkout') {
            steps {

                      git branch: 'master', credentialsId: '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', url: 'https://github.com/motipa/V7App.git'

                echo 'checkout App'
                  }
                  }
                   stage('Restore') {
            steps {

                    bat "dotnet restore ${V7App}\\ClubApp.Api.sln"

                echo 'Restore App'
                  }
                  }
stage('Clean') {
  steps {
    bat "msbuild.exe ${V7App}\\ClubApp.Api.sln.sln" /nologo /nr:false /p:platform=\"x64\" /p:configuration=\"release\" /t:clean"
  echo 'clean App'
  }
}




        
    }
}
