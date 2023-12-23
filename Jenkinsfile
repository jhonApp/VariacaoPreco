pipeline {
    agent any

    stages {
        stage('Build Image') {
            steps {
                script {
                    echo 'Iniciando a construção da imagem Docker...'
                    dockerapp = docker.build('jhon/variacaopreco.api', '-f ./src/VariacaoPreco.API/Dockerfile ./src/VariacaoPreco.API')
                    sh "echo ${dockerapp}"
                }
            }
        }
        stage('Test') {
            steps {
                echo 'Iniciando os testes'
                // Adicione mais comandos de teste e verificação aqui
                // Por exemplo, echo de variáveis ou informações de contexto relevantes para os testes
            }
        }
        stage('Deploy') {
            steps {
                echo 'Iniciando o deploy'
                // Adicione mais comandos de deploy e verificação aqui
                // Por exemplo, echo de variáveis ou informações relevantes para o deploy
            }
        }
    }
}
