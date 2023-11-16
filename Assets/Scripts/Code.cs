using System.Collections;
using System.Collections.Generic;
using UnityEditor.VersionControl;
using UnityEngine;

public class Code : MonoBehaviour
{
    public GameObject mission;
    public GameObject change;
    public GameObject active;
    public GameObject inactive;
    public GameObject inactiveLines;
    public GameObject activeLines;
    public GameObject erroScreen;
    private GameObject Player;
    private string message;

    //input

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        //Player.GetComponent<FirstPersonController>().enabled = false;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        FirstPersonController.cameraCanMoveStatic = false;
    }

    public void Close()
    {
        if (inactive != null) inactive.SetActive(false);
        if (change != null) change.SetActive(true);
        if (mission != null) mission.SetActive(true);
        gameObject.SetActive(false);
        if (inactiveLines != null) inactiveLines.SetActive(false);
        if (activeLines != null) activeLines.SetActive(true);
        if (active != null) active.SetActive(true);
        Cursor.visible = false;
        FirstPersonController.cameraCanMoveStatic = true;
        //Player.GetComponent<FirstPersonController>().enabled = true;
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private IEnumerator WaitForSceneLoad()
    {
        erroScreen.SetActive(true);
        yield return new WaitForSeconds(5);
        erroScreen.SetActive(false);
    }
    public void SetMessage(string message)
    {
        this.message = message;
    }

    //Close(); certo
    //StartCoroutine(WaitForSceneLoad()); erro

    // inicio analise de codigos

    public void ChallengeWakeUp()
    {
        if (
            message.Contains("if (jogador.deitado) {")
            && message.Contains("jogador.deitado = false;")
            && message.Contains("jogador.levantado = true;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeOpenDoor()
    {
        if (
            message.Contains("if (porta.id == chave.id_porta) {")
            && message.Contains("porta.trancado = false;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeCleanPool()
    {
        if (
            message.Contains("while (!piscina.limpa) {")
            && message.Contains("redinha.limpar(piscina);")
            && message.Contains("if (piscina.sujeira<1) {")
            && message.Contains("piscina.limpa = true;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeFillPool()
    {
        if (
            message.Contains("while(piscina.agua != 10000) {")
            && message.Contains("piscina.cloro = piscina.cloro + 4;")
            && message.Contains("piscina.agua = piscina.agua + 1000;")
            && message.Contains("if (piscina.agua / piscina.cloro == 1000) {")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeDogFood()
    {
        if (
            message.Contains("while (int pote.comida != 200) {")
            && message.Contains("if (pote.comida < 200) {")
            && message.Contains("if (pote.comida > 200) {")
            && message.Contains("pote.retiraComida();")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeOrganizeGarden()
    {
        if (
            message.Contains("fila1[0] = 'jarra';")
            && message.Contains("fila1[1] = 'escorredor';")
            && message.Contains("fila1[2] = 'prato';")
            && message.Contains("fila1[3] = 'pote';")
            && message.Contains("fila2[0] = 'pote';")
            && message.Contains("fila2[1] = 'garrafa';")
            && message.Contains("fila2[2] = 'caneca';")
            && message.Contains("fila2[3] = 'vasilha';")
            && message.Contains("fila3[0] = 'pote';")
            && message.Contains("fila3[1] = 'bule';")
            && message.Contains("fila3[2] = 'xicara';")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeFertilizer()
    {
        if (
            message.Contains("while (fertilizantes > 1 && armazem.fertilizante < 10) {")
            && (
                message.Contains("fertilizantes = fertilizantes - 1")
                || message.Contains("fertilizantes--")
            )
            && (
                message.Contains("armazem.fertilizante = armazem.fertilizante + 1")
                || message.Contains("armazem.fertilizante++")
            )
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeWaterPlant()
    {
        if (
            message.Contains("for (planta of plantas) {")
            && (
                message.Contains("quantPlantas = quantPlantas + 1")
                || message.Contains("quantPlantas++")
            )
            && message.Contains("planta.regado = true;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeBoxes()
    {
        if (
            message.Contains("for (int i = 0; i < caixa.Lenght; i++ {")
            && message.Contains("for (int j = 0; j < caixa[i].caixote.Lenght; j++ {")
            && message.Contains("for (int j = 0; j < caixa[i].caixote.Lenght; j++ {")
            && (
                message.Contains("if (caixa[i].caixote[j].alimento == 'batata' || caixa[i].caixote[j].alimento == ‘farinha’) {")
                || message.Contains("if (caixa[i].caixote[j].alimento == ‘farinha’ || caixa[i].caixote[j].alimento == ‘batata’) {")
            )
            && message.Contains("jogador.pegar(caixa[i].caixote[j].alimento);")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeFruits()
    {
        if (
            message.Contains("for each fruta in lista {")
            && message.Contains("jogador.pegar(fruta);")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeAnimalFood()
    {
        if (
            message.Contains("for each animal in animais {")
            && message.Contains("quantidade_total_comida = quantidade_total_comida + (comida_necessaria[animal] * quantidade_animais[animal]);")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeBridge1()
    {
        if (
            message.Contains("if (ponte.inteira == false) {")
            && message.Contains("pedreiro1.consertar();")
            && message.Contains("pedreiro2.consertar();")
            && message.Contains("pedreiro3.consertar();")
            && message.Contains("ponte.inteira = true;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeBridge2()
    {
        if (
            message.Contains("while(ponte.inteira == false) {")
            && message.Contains("switch (trabalho) {")
            && message.Contains("case 1:")
            && message.Contains("pedreiro1.consertar(tarefa);")
            && message.Contains("pedreiro1.ocupado = true;")
            && message.Contains("case 2:")
            && message.Contains("pedreiro2.consertar(tarefa);")
            && message.Contains("pedreiro2.ocupado = true;")
            && message.Contains("case 3:")
            && message.Contains("pedreiro3.consertar(tarefa);")
            && message.Contains("pedreiro3.ocupado = true;")
            && message.Contains("if (pedreiro1.ocupado && pedreiro2.ocupado && pedreiro3.ocupado) {")
            && message.Contains("ponte.inteira = true;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeBridge3()
    {
        if (
            message.Contains("while(ponte.inteira == false) {")
            && message.Contains("switch (trabalho) {")
            && message.Contains("case 1:")
            && message.Contains("pedreiro1.consertar(tarefa1, tarefa2);")
            && message.Contains("pedreiro1.ocupado = true;")
            && message.Contains("case 2:")
            && message.Contains("pedreiro2.consertar(tarefa1, tarefa2);")
            && message.Contains("pedreiro2.ocupado = true;")
            && message.Contains("case 3:")
            && message.Contains("pedreiro3.consertar(tarefa1, tarefa2);")
            && message.Contains("pedreiro3.ocupado = true;")
            && message.Contains("if (pedreiro1.ocupado && pedreiro2.ocupado && pedreiro3.ocupado) {")
            && message.Contains("ponte.inteira = true;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeTirePressure()
    {
        if (
            message.Contains("pneu.tirarTampa();")
            && message.Contains("while (pneu.pressao < 36) {")
            && message.Contains("pneu.pressao++;")
            && message.Contains("pneu.colocarTampa();")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengePaintCar()
    {
        if (
            message.Contains("if (carro.cor !== vermelho) {")
            && message.Contains("jogador.pintar(carro, ‘vermelho’);")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeCleanDesk()
    {
        if (
            message.Contains("for (int i = 0; i < mesa.Length); i++ {")
            && message.Contains("if (mesa[i] == ‘garrafa de agua’ || mesa[i] == ‘pasta’ || mesa[i] == ‘pacote’) {")
            && message.Contains("mesa[i].pop();")
            && (
                message.Contains("i = i - 1")
                || message.Contains("i--")
            )
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeOrganizeFiles()
    {
        if (
            message.Contains("prateleira[0] = ‘preto’;")
            && message.Contains("prateleira[1] = ‘preto’;")
            && message.Contains("prateleira[2] = ‘preto’;")
            && message.Contains("prateleira[3] = ‘preto’;")
            && message.Contains("prateleira[4] = ‘azul’;")
            && message.Contains("prateleira[5] = ‘azul’;")
            && message.Contains("prateleira[6] = ‘vermelho’;")
            && message.Contains("prateleira[7] = ‘vermelho’;")
            && message.Contains("prateleira[8] = ‘vermelho’;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeHelpTI()
    {
        if (
            message.Contains("if (cadastro.ativo) {")
            && message.Contains("for (int i = 0; i <= cadastro.Lenght; i++) {")
            && message.Contains("Console.WriteLine(cadastro.pagamentos[i]);")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeBossPC()
    {
        if (
            message.Contains("computador.wifi.nome = ‘sala do cassio’;")
            && message.Contains("computador.wifi.senha = ‘123456’;")
            && message.Contains("if (computador.wifi.nome == ‘sala do cassio’ && computador.wifi.senha = ‘123456’) {")
            && message.Contains("computador.wifi.conectado = true;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeLibraryPC()
    {
        if (
            message.Contains("computador.volume = 0;")
            && message.Contains("computador.brilho = computador.brilho / 2;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeLastBook()
    {
        if (
            message.Contains("ultimoLivro = historico[historico.Lenght - 1];")
            || message.Contains("ultimoLivro = historico.pop();")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengePortugueseBooks()
    {
        if (
            message.Contains("foreach(livro in historico) {")
            && message.Contains("if (livro.tema = ‘Português’) {")
            && (
                message.Contains("livrosPortuguesPegos = livrosPortuguesPegos + 1;")
                || message.Contains("livrosPortuguesPegos++")
            )
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeBiggestMathBook()
    {
        if (
            message.Contains("foreach(livro in estante) {")
            && message.Contains("if (livro.paginas > maiorLivro.paginas) {")
            && message.Contains("maiorLivro = livro;")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeRemoveNotHistBook()
    {
        if (
            message.Contains("foreach (livro in estanteHistoria) {")
            && message.Contains("if (livro.tema != ‘História’) {")
            && message.Contains("livro.pop();")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeOrganizeBooks()
    {
        if (
            message.Contains("foreach (livro in livrosDaMesa) {")
            && message.Contains("switch (livro.tema) {")
            && message.Contains("case ‘Matemática’:")
            && message.Contains("estanteMatematica.push(livro);")
            && message.Contains("case ‘Português’:")
            && message.Contains("estantePortugues.push(livro);")
            && message.Contains("case ‘História’:")
            && message.Contains("estanteHistoria.push(livro);")
            && message.Contains("case ‘Geografia’:")
            && message.Contains("estanteGeografia.push(livro);")
            && message.Contains("case ‘Quimíca’:")
            && message.Contains("estanteQuimica.push(livro);")
            && message.Contains("case ‘Ficção’:")
            && message.Contains("estanteFiccao.push(livro);")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }


    // escola (opcionais)
    public void ChallengeWritePortugueseQuestion()
    {
        if (
            message.Contains("Console.WriteLine(“Escreva uma proparoxítona acentuada:”);")
            && message.Contains("string resposta  = Console.ReadLine();")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }
    public void ChallengeWriteQuestion()
    {
        if (
            message.Contains("Console.WriteLine(“Qual o seu nome?”)")
            && message.Contains("string nome = Console.ReadLine();")
            && message.Contains("Console.WriteLine(“Então ” + nome + “, quantas vogais tem seu nome?”)")
            && message.Contains("string vogais = Console.ReadLine();")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }

    public void ChallengeFirstLetterFruit()
    {
        if (
            message.Contains("Console.WriteLine(“Digite uma fruta que começa com uma vogal?”)")
            && message.Contains("string frutaVogal = Console.ReadLine();")
            && message.Contains("Console.WriteLine(“Digite uma fruta que começa com uma consoante?”)")
            && message.Contains("string frutaConsoante = Console.ReadLine();")
            && message.Contains("Console.WriteLine(“Fruta que começa com vogal: ” + frutaVogal + “. Fruta que começa com consoante: ” + frutaConsoante)")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }

    public void ChallengeCalcArea()
    {
        if (
            message.Contains("area = (15 * 25) / 2")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }

    public void ChallengeCircleArea()
    {
        if (
            message.Contains("area = (17 * 17) * 3,14")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }

    public void ChallengeCalcFunction()
    {
        if (
            message.Contains("y = (10 * (5^2)) + (8 * 5) + 12")
        )
        {
            Close();
        }
        else
        {
            StartCoroutine(WaitForSceneLoad());
        }
    }

    // fim analise de codigos
}
