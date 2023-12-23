pipeline {
    agent any

    stages {
        stage('Build') {
            steps {
                echo 'Iniciando a pipeline'
            }
        }
        stage('Test') {
            steps {
                // Comandos para executar testes
                // Por exemplo: sh 'npm test' ou 'dotnet test'
            }
        }
        stage('Deploy') {
            steps {
                // Comandos para implantar o projeto
                // Por exemplo: sh 'npm deploy' ou 'docker push'
            }
        }
    }
}
