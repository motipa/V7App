pipeline {
    agent any

    stages {
        stage('clean') {
            steps {
                ech 'clean App'
              cleanWs()
                  }
                  }
                   stage('Test') {
            steps {

                      git branch: 'master', credentialsId: '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', url: '<url to your GitHub repository'

                echo 'Test App'
                  }
                  }
                   stage('Deploy') {
            steps {
                echo 'Deploy App'
                  }
                  }
    }
}
