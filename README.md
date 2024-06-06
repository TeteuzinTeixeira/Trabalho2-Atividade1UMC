## Tarefa DesignPattern

# Feitos por
- Mateus Teixeira Gomes - RGM: 11232402563
- Iago da Silva Lima - RGM: 11232402565

# Documentação Básica - Resolvedor de Equações Lineares

Este projeto fornece implementações em C# para resolver sistemas de equações lineares utilizando diferentes estratégias:

1. Eliminação Gaussiana
2. Decomposição LU
3. Iteração de Jacobi

## Interfaces e Estratégias de Resolução

### Interface ISolverStrategy

A interface `ISolverStrategy` define o contrato para todas as estratégias de resolução.

Métodos:
- `Solve(double[,] A, double[] B)`: Resolve um sistema de equações lineares representado pela matriz `A` e o vetor `B`.

### Implementação de Eliminação Gaussiana

A classe `GaussianEliminationSolver` implementa a estratégia de resolução usando a eliminação gaussiana.

Métodos:
- `Solve(double[,] A, double[] B)`: Implementa o algoritmo de eliminação gaussiana para resolver o sistema.

### Implementação de Decomposição LU

A classe `LUSolver` implementa a estratégia de resolução usando a decomposição LU.

Métodos:
- `Solve(double[,] A, double[] B)`: Implementa o algoritmo de decomposição LU para resolver o sistema.

### Implementação de Iteração de Jacobi

A classe `JacobiSolver` implementa a estratégia de resolução usando a iteração de Jacobi.

Métodos:
- `Solve(double[,] A, double[] B)`: Implementa o método de iteração de Jacobi para resolver o sistema.

## Geração de Matriz e Vetor

A classe `MatrixGenerator` fornece métodos para gerar matrizes e vetores aleatórios para teste.

Métodos:
- `GenerateMatrix(int size)`: Gera uma matriz aleatória de tamanho `size x size`.
- `GenerateVector(int size)`: Gera um vetor aleatório de tamanho `size`.

## Contexto do Solucionador

A classe `SolverContext` fornece um contexto para resolver sistemas de equações lineares usando diferentes estratégias.

Métodos:
- `SetStrategy(ISolverStrategy strategy)`: Define a estratégia de resolução.
- `Solve(double[,] A, double[] B)`: Resolve o sistema de equações lineares usando a estratégia definida.

## Programa Principal

O programa principal (`Program`) demonstra como usar as diferentes estratégias de resolução para resolver um sistema de equações lineares.

---

Esse é um documento básico de documentação que descreve a estrutura e funcionalidade do projeto. Para detalhes mais específicos, consulte a documentação do código-fonte.
