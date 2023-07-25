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
                ech 'Test App'
                  }
                  }
                   stage('Deploy') {
            steps {
                echo 'Deploy App'
                  }
                  }
    }
}
