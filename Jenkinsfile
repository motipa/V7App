pipeline {
    agent any

    stages {
        stage('clean') {
            steps {
                echo 'clean App'
              cleanWs()
                  }
                  }
                 
                   stage('build') {
            steps {

                   dotnet build V7App/ClubApp.sln 

                  echo 'build App'
                  }
                  }





        
    }
}
