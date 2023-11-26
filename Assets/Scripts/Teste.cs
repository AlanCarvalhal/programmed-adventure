using UnityEngine;

public class CodeAnalyzer : MonoBehaviour
{
    public bool ContainsIfForEvenNumber(string code)
    {
        if (code.Contains("if") && code.Contains("int number") && code.Contains("% 2 == 0"))
        {
            return true;
        }
        return false;
    }

    // Exemplo de uso
    void Start()
    {
        string playerCode = @"
            using System;

            class TestClass
            {
                void TestMethod(int number)
                {
                    if (number % 2 == 0)
                    {
                        // Some code for even number
                    }
                }
            }";

        bool containsIfForEvenNumber = ContainsIfForEvenNumber(playerCode);

        if (containsIfForEvenNumber)
        {
            Debug.Log("O c�digo do jogador cont�m um 'if' para verificar se o n�mero � par.");
        }
        else
        {
            Debug.Log("O c�digo do jogador n�o cont�m um 'if' para verificar se o n�mero � par.");
        }
    }
}
