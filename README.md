### Projeto Felpudo e Fofura

Projeto avaliativo para o curso de Jogos Digitais na Universidade do Estado da Bahia, desenvolvidos por Jonatas Argolo e Isabela Coelho.

Foi solicitado pelo docente uma pequena história entre os sprites Felpudo e Fofura, de no mínimo 3 cenas para serem exibidas, neste trabalho escolhi por criar um pequeno entre os personagens no Carnaval de Salvador, Bahia, no Circuito Osmar (Campo Grande).

O programa começa com Felpudo e Fofura se encontrando em um dos locais de rota do trio, eles se aproximam um em direção ao outro e ao se tocarem, particulas de coração aparecem na tela.
> Nesta primeira cena foram criadas 3 scripts, respectivamente: MoveFelpudo, MoveFofura e Pararaoencontro.

# MoveFelpudo e MoveFofura

Ambos Scripts foram feitos de forma idêntica:
> Cada um necessitou de 3 variáveis, uma para guardar a referência da posição do outro personagem, uma para modificar sua velocidade, e uma booleana para fazerem parar enquanto nao se encostaram

´´´
public Transform forura;
public float velocidade = 1.5f;
private bool podeMover = true;

´´´
A forma que utilizei para  fazer os personagens se moverem foi utilizando um ´Vector3´ e o método ´MoveTowards()´

´´´
transform.position = Vector3.MoveTowards(
            transform.position,
            destino,
            velocidade * Time.deltaTime // detalhe para esse método que faz a velocidade ficar independente dos quadros por segundo.
        );
´´´

# Pararaoencontro

Este script faz as verificações do movimento dos personagens e exibi os corações se as condições forem atingidas.
> 

Nosso projeto foi desenvolvido na Unity 6 utilizando C# e dividido em três cenas. Na primeira, utilizamos scripts para movimentar dois personagens e detectar a aproximação entre eles, acionando um sistema de partículas em formato de corações. Na segunda, implementamos saltos automáticos utilizando Rigidbody2D e efeitos de confetes com Particle System. Na terceira, programamos o movimento de um veículo e utilizamos Coroutines para controlar os intervalos entre as ações. Por fim, utilizamos o SceneManager para realizar as transições automáticas, criando uma animação contínua com início, desenvolvimento e encerramento.


PLAY UNITY:
https://play.unity.com/en/games/cf80a6be-1ced-4b88-9021-2968dba93497/felpudo-e-fofura-on-carnival
