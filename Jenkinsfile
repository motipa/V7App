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
                script{ zip zipFile: 'ClubApp.Api/bin/Debug/netcoreapp3.1/ClubApp.Api.zip', archive: false, dir: 'ClubApp.Api' }
                
                bat '"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:package="%WORKSPACE%\\ClubApp.Api\\bin\\Debug\\netcoreapp3.1\\ClubApp.Api.zip" -dest:auto -setParam:"IIS Web Application Name"="jenkinsite" -skip:objectName=filePath,absolutePath=".\\\\PackagDemoeTmp\\\\Web.config$" -enableRule:DoNotDelete -allowUntrusted=true'
                
                
           
            }
        }

        }
            
        }
       
    

