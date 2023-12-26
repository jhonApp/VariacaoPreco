# Guia de Deploy da Aplicação

Este documento descreve os passos necessários para implantar a aplicação.

## Passos para Deploy Manual

1. **Preparação do Ambiente:**
   - Será desponibilizado no docker hub o container com as imagens, segue o link

2. **Empacotamento e Transferência da Aplicação:**
   - Gere o pacote da aplicação usando o comando `dotnet publish`.
   - Transfira o pacote para o servidor usando SCP ou outra ferramenta de transferência.

3. **Configuração no Servidor:**
   - Descompacte o pacote no servidor.
   - Execute os comandos de inicialização da aplicação.

4. **Testes e Verificação:**
   - Realize testes manuais para garantir que a aplicação esteja funcionando corretamente.

5. **Configurações Adicionais:**
   - Faça as configurações adicionais necessárias no servidor, se aplicável.

## Observações

Certifique-se de ajustar os comandos e passos de acordo com o seu ambiente específico e as necessidades da aplicação.
