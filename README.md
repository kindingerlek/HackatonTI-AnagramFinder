# HacktonTI-AnagramFinder

## O Desafio:

### Anagramas!
Um anagrama é uma palavra ou frase formada com o re-arranjo de todas as letras de uma outra palavra ou frase (sem sobra ou falta). Exemplos:

- A palavra `barco` é um anagrama da palavra `cobra` (todas as letras de cobra são usadas em barco).
- A palavra `mar` **não é** um anagrama da palavra `roma` (a letra 'o' em 'roma' não foi usada).
- A palavra `sal` **não é** um anagrama da palavra `mal` (a letra 's' de 'sal' não existe em 'mal').

### O problema 
Escreva um programa na sua linguagem e bibliotecas preferidas que:

- [x] Leia a expressão (que pode ser uma frase ou apenas uma palavra) a ser usada para a criação dos anagramas da linha de comando.
  - [x] Apenas as letras de 'A' a 'Z' deverão ser consideradas (ignore espaços e converta todas as letras minúsculas para maíusculas).
  - [x] Retorne erro e aborte a execução se caracteres inválidos forem encontrados na expressão (qualquer caracter não alfabético que não seja espaço, incluindo números, pontuação, ou caracteres acentuados).

- [x] Leia uma lista de palavras válidas do arquivo `words.txt` ([Download](https://osprogramadores.com/desafios/d06/words.txt)). O arquivo é formatado com uma palavra por linha, com palavras da língua inglesa *(Nota: apesar de várias tentativas, o autor não conseguiu achar uma lista 'limpa' de palavras da língua portuguesa)*.

- [x] Imprima todas as combinações possíveis de anagramas (sem repetição de linhas ou palavras). Os anagramas devem conter apenas palavras válidas (lidas do arquivo acima).

- [x] O formato de saída deve conter múltiplas linhas (uma por anagrama), com as palavras ordenadas dentro de cada linha.

- [x] O programa deve ser capaz de calcular e imprimir a lista de anagramas possíveis para uma expressão de até 16 caracteres em menos de 60 segundos.