# WebAPI_Security_Camadas

### Arquitetura em 3 Camadas:
* Camada Aplicação
* Camada de Negócio
* Camada de Infraestrutura

* #### **Arquitetura em camadas é um conjunto de projetos criados dentro da solução.**
* São projetos referenciados entre si.
* Segregando assim suas responsabilidades entre .csproj em C#
* Quando temos um projeto em camadas precisamos tomar cuidado para não expor a camada mais baixa na camada mais alta da solução.

* _Camada Aplicação_ **não é uma** camada de Injeção de dependência
* Camada de aplicação é responsável por ter:
    * Projetos Console
    * Projetos API
    * WebSite
    * Jobs
* Ela possui uma interação com a domínio(negócio) em sua forma mais simples.

* Camada de Negócio (Domain) e responsável por ter alguns pontos:
  * Negócio
    * *Serviços*
  * Entidades
  * Contexto
  * _Interfaces de Repositório e Domínio_
* Essa camada ela precisa ficar totalmente desacoplada de qualquer outro projeto da solução



