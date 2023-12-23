pipeline {
    agent any

    stages {
        stage('Build Image') {
            steps {
                script {
                    dockerapp = docker.build('jhon/variacaopreco.api', '-f ./src/VariacaoPreco.API/Dockerfile ./src')
                }
            }
        }
        stage('Test') {
            steps {
                echo 'Iniciando os testes'
            }
        }
        stage('Deploy') {
            steps {
                echo 'Iniciando o deploy'
            }
        }
    }
}
