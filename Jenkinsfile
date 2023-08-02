pipeline {
    agent any
    environment {
        dotnet = 'C:\\Program Files\\dotnet\\dotnet.exe'
    }
    stages {
        stage('Checkout Stage') {
            steps {
                git credentialsId: 'v', url: 'https://github.com/motipa/V7App.git', branch: 'master'
            }
        }

         stage('Build Stage') {
            steps {
                bat "\"C:/Program Files/dotnet/dotnet.exe\" restore \"${workspace}/ClubApp.sln\""
                bat "\"C:/Program Files/dotnet/dotnet.exe\" build \"${workspace}/ClubApp.sln\""

            }
        }

        stage('Deploy Stage') {
            steps {
                
     sh 'mkdir -p archive'
     sh 'echo test > archive/test.txt'
     zip archive: true, dir: 'archive', glob: '', zipFile: 'ClubApp.zip'
                
           
            }
        }

        }
            
        }
       
    

