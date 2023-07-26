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

                   dotnet build ClubApp.sln 

                  echo 'build App'
                  }
                  }





        
    }
}
