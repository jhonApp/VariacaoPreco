/* groovylint-disable-next-line CompileStatic */
pipeline {
    agent any

    stages {
        stage('Build Image') {
            steps {
                script {
                    dockerapp = docker.build('jhon/variacaopreco.api', '-f ./src/VariacaoPreco.API/Dockerfile ./src/VariacaoPreco.API')
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
