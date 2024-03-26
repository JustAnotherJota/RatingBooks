# RatingBooks

Sistema de Livros para avaliar e agendar um compromisso para continuar a leitura (Projeto ainda em andamento)

O projeto inicialmente foca no backend, sendo uma aplicação .Net 6.0 com o uso de pacotes NuGet como EntityFramework, Identity e AutoMapper. O banco de dados usado é o Microsoft SQL Server. 

A ideia é de um site em que a funcionalidade principal é na avaliação e descrição dos livros, contendo também a possibilidade de um agendamento com o livro criado para que possa ser lido posteriormente, fazendo com que haja um comprometimento pela parte do usuário. Vale citar que ideias como progressão de leitura foram levados em consideração, porém, inicialmente o projeto contará com a criação e autenticação de um usuário e, assim, cada usuário capaz de fornecer as informações dos livros que está lendo no presente momento, assim como também a possibilidade de registrar livros que foram lidos no passado, essa marcação se da pela funcionalidade de Status do Livro em que se pode declarar o livro como concluido. A avaliação por parte dos livros ainda é dada em um rating de 0 a 5 estrelas e não em uma nota de 1 a 10, foram levados em consideração sites de compras, como Amazon, MagazineLuiza e MercadoLivre, que avaliam o produto até 5 estrelas e também sites que avaliam animações, como o MyAnimeList, qual é possível dar uma nota de até 10.

O projeto conta como uma estrutura no qual separamos em:

## Models
- No Models, informamos quais propriedades e métodos nosso Modelo principal de classe irá possuir.
## Controllers
- No Controller é onde trabalhamos acionando a requisição da API, definindo parte da rota através dos DataAnnotations. 
## Services 
- Aqui fica inserido as regras e o que a requisição invocada deve fazer, afim de ter um maior encapsulamento e também indepedência do código, podendo ser reaproveitado, caso necessário.
## Profiles
- O profile tem o intuito de realizar o mapeamento para os dados de Models e dos DTOs serem transmitidos entrem sí, possibilitando apenas o trafego de dados necessários.
## Data
- Aqui será onde possibilitamos a interação com o banco do dados e também onde declaramos nossos DTOs.

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

Tem-se uma ideia inicial de como poderia ser realizado o front-end da aplicação:

Seria usado o framework Angular

	-> As pessoas poderão adicionar uma imagem do livro como capa e abaixo terão informações sobre a avaliação, status de leitura e agendamento

	-> Será possível organizar por ordem de estrelas, ordem de status e ordem de capítulos/páginas
