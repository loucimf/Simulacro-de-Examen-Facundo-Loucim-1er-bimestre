using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeladeriaScript : MonoBehaviour
{
    enum IcecreamOpts
    {
        DDL,
        CHO,
        FRU,
    }

    public string nameUser;
    public int gramsOfIcecream;
    [field: SerializeField] private IcecreamOpts _icecreamChosen;

    private int _minGrams = 250;
    private int _maxGrams = 3000;

    private float _pricePerGram = 1.25f;

    void Start()
    {   
        if (!ValidateIcecream(gramsOfIcecream))
        {
            return;
        }

        float totalPrice = CalculatePrice(_pricePerGram, gramsOfIcecream);

        if (_icecreamChosen == IcecreamOpts.FRU)
        {
            float discount = totalPrice * 0.1f;
            totalPrice -= discount;
        }

        Debug.Log("Gracias " + nameUser + "! El precio total para tu helado de " + _icecreamChosen + " es de: " + totalPrice);
    }

    bool ValidateIcecream(int grams)
    {   

        // no puedo validar el enum, porque no existe en Enum.isDefined()  (  no hace falta, but its nice (:  )

        if (grams < _minGrams || grams > _maxGrams)
        {
            Debug.Log("Cantidad de helado INVALIDA, debe ser menor a: " + _maxGrams + " y mayor a: " + _minGrams + "$");
            return false;
        }

        // if (!Enum.isDefined(typeof(IcecreamOpts), _icecreamChosen))
        //{
        //  Debug.Log("Elegi un helado valido.")
        //  return false;
        //}
        return true;
    }

    float CalculatePrice(float price, int totalGrams)
    {
        return totalGrams * price;
    }

}
