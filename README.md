# RatingBooks

Sistema de Livros para avaliar e agendar um compromisso para continuar a leitura (Projeto ainda em andamento)

O projeto inicialmente foca no backend, sendo uma aplicação .Net 6.0 com o uso de pacotes NuGet como:
	
 	-> EntityFrameworkCore
  	-> EntityFrameworkSqlServer
  	-> Identity
   	-> AutoMapper
    
O banco de dados usado é o Microsoft SQL Server em uma instância local.

A ideia é de uma aplicação em que a funcionalidade principal é na avaliação e descrição dos livros, contendo também a possibilidade de um agendamento com o livro criado para que possa ser lido posteriormente, fazendo com que haja um comprometimento pela parte do usuário. Vale citar que ideias como progressão de leitura foram levados em consideração, porém, inicialmente o projeto contará com a criação e autenticação de um usuário e, assim, cada usuário capaz de fornecer as informações dos livros que está lendo no presente momento, assim como também a possibilidade de registrar livros que foram lidos no passado, essa marcação se da pela funcionalidade de Status do Livro em que se pode declarar o livro como concluido. 

A avaliação por parte dos livros ainda é dada em um rating de 0 a 5 estrelas e não em uma nota de 1 a 10, foram levados em consideração sites de compras, como Amazon, MagazineLuiza e MercadoLivre, que avaliam o produto até 5 estrelas e também sites que avaliam animações, como o MyAnimeList, qual é possível dar uma nota de até 10.

O projeto conta como uma estrutura no qual separamos em:  

## A estrutura foi atualiazada para o padrão DDD (Domain Driven Design) :

## Application
- É a camada da aplicação no qual depende da camada de Domain, podendo então usar das Entidades e de contratos que as interfaces disponibilizam. A aplicação pode também ter contato direto com a camada de Persistence, usando dos Repositorios para excercer seus Serviços
## Domain
- Essa camada não deve referenciar a uma outra e se representar os conceitos de negócios. Ela irá ser responsável pela criação das Entidades, dos contratos do repositorio e dos Dtos.
## Persistance
- Aqui temos a camada responsável pelos dados poderem transitar entre o banco de dados e a aplicação, fazendo uso de entidades e de bibliotecas como o EntityFramework para ser capaz de guardar os dados

## Então temos:

Sistema de Avaliação : 
	
    -> nota de 0 a 5.

Registro de usuário / Nome de Usuário e Senha

	-> Para criar uma conta, será necessário fornecer:
	nome de usuário, senha, repetir a senha e data de nascimento.
 
	-> O livro poderá ter Status do Livro e em qual estágio o usuário está
	Status da Leitura possíveis: iniciado, metade do livro, quase concluído, concluído


Uma funcionalidade que será implementada será: se o Status da Leitura for (!concluído / diferente de concluido)

	-> Gostaria de agendar uma data e horário para continuar a leitura?
	-> reservar data para ler os livros


Para Registrar um livro, será possível adicionar alguma das seguintes propriedades:

	-> Quantas páginas e capítulos tem (opcional)
	-> Quantas estrelas você daria a ele
	-> Status da Leitura
	-> Agendar uma data para continuar a leitura se desejar e não tiver concluído o livro
	-> Fazer sua própria análise do livro
