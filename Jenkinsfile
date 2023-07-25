pipeline {
    agent any

    stages {
        stage('clean') {
            steps {
                ech 'clean App'
              cleanWs()
                  }
                  }
                 
                   stage('Restore') {
            steps {

                    bat "dotnet restore ${V7App}\\ClubApp.Api.sln"

                echo 'Restore App'
                  }
                  }





        
    }
}
