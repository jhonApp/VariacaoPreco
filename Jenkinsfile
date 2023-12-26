pipeline {
    agent any

    stages {
        stage('Test') {
            steps {
                echo 'Iniciando os testes'
                sh 'dotnet test ./src/VariacaoPreco.Tests/VariacaoPreco.Tests.csproj'
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
