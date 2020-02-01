using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Classe représentant la charge utile
/// d'un évènement.
/// </summary>
public class GameEventPayload
{

    /// <summary>
    /// Charge utile de l'évènement
    /// </summary>
    private Dictionary<string, System.Object> payload;

    /// <summary>
    /// Méthode permettant de récupérer une
    /// valeur du payload sous forme d'un objet
    /// donné en paramètre
    /// </summary>
    public T Get<T>(string key) {
        return (T) payload[key];
    }

    /// <summary>
    /// Constructeur de charge utile d'évènement de jeu
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public GameEventPayload(Dictionary<string, System.Object> o = null)
    {
        payload = o;
    }
}

/// <summary>
/// Classe permettant d'utiliser les Unity Events
/// avec un paramètre.
/// </summary>
/// <typeparam name="GameEventPayload"></typeparam>
[System.Serializable]
public class CustomGameEvent : UnityEvent<GameEventPayload> 
{}

/// <summary>
/// Classe encapsulant un UnityEvent, permettant d'y ajouter des comportements
/// personnalisés
/// </summary>
public class GameEvent 
{
    /// <summary>
    /// Nom de l'évènement pour les affichages de logs
    /// </summary>
    public string name;

    /// <summary>
    /// UnityEvent utilisant des GameEventPayloads.
    /// </summary>
    public CustomGameEvent Event;

    /// <summary>
    /// Constructeur d'évènement de jeu.
    /// </summary>
    /// <param name="name">(Optionnel) nom de l'évènement pour les logs</param>
    public GameEvent(string name = "Unknown Event")
    {
        this.name = name;
        this.Event = new CustomGameEvent();
    }

    /// <summary>
    /// Méthode permettant l'invocation de l'évènement actuel et de ses parents
    /// </summary>
    public void Invoke(Dictionary<string, System.Object> o = null) 
    {
        GameEventPayload p = new GameEventPayload(o);

        Event.Invoke(p);
    }

    /// <summary>
    /// Méthode permettant l'invocation de l'évènement actuel et de ses parents
    /// </summary>
    public void Invoke(GameEventPayload o) 
    {
        Event.Invoke(o);
    }

    /// <summary>
    /// Méthode permettant d'ajouter un listener appelé lorsque cet évènement est invoqué
    /// </summary>
    /// <param name="call">Action à effectuer lors de l'invoquation de l'évènement</param>
    public void AddListener(UnityAction<GameEventPayload> call) 
    {
        Event.AddListener(call);
    }

    /// <summary>
    /// Méthode permettant de supprimer tous les listeners attachés a 
    /// l'évènement de jeu.
    /// </summary>
    public void RemoveAllListeners() 
    {
        Event.RemoveAllListeners();
    }

    /// <summary>
    /// Méthode permettant de supprimer un listener particulier de l'évènement
    /// de jeu.
    /// </summary>
    /// <param name="call"></param>
    public void RemoveListener(UnityAction<GameEventPayload> call)
    {
        Event.RemoveListener(call);
    }
}