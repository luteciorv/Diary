# Diary---Webforms
Curso de Webforms - Agenda Online

Dentro da solução você encontrará dois projetos
* Diary
* DiaryEntityFramework

Ambos possuem:
> * Tela de login com validação
> * Tela inicial da aplicação
> * Logout
> * CRUD de usuários
> * CRUD de contatos

### Diferenças
O que difere um do outro é que no projeto Diary eu usei consultas diretas ao banco de dados. Expressões diretas, comandos em string, SqlConnection e etc.
Já no projeto DiaryEntityFramework, como o próprio nome sugere, eu utilizei a principal Framework do .Net para lidar com banco de dados. As mesmas operações
que eu realizei no projeto Diary eu fiz neste, mas usando o EntityFramework como ferramenta

### Vantagens de usar o EntityFramework
* Maior flexibilidade no código
* Melhor manutenção
* Organização e atribuição de função (Cada classe respeita suas funções e trata única e excluivamente delas)
* Performance (Utilizei métodos Async para o CRUD)
* Legível

### Teste por sí mesmo
A melhor forma de comparar ambos é na tela de Contatos. Tentei deixar a interface de ambos idêntica, divergindo apenas na paginação do GridView, já que no projeto
DiaryEntityFramework eu não programei a paginação por conta de alguns fatores de retorno de função (algumas coisas a mais são exigidas quando se programa o GridView
na mão utilizando certos recursos).
Entrando nessa tela, você pode realizar o CRUD de contatos tranquilamente. Aconselho a executar ambos os códigos e testar eles "juntos". Suponho que a diferença de
desempenho é imperceptível, mas o código é totalmente bem notado.
