using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// An event invoker
/// </summary>
public class Invoker : MonoBehaviour
{
    // add your fields for your message event support here
    MessageEvent messageEvent;
    CountMessageEvent countMessageEvent;

    // add your fields for your count message event support here
    Timer timer;
    int count=0;

    /// <summary>
    /// Awake is called before Start
    /// </summary>
    public void Awake()
    {
        messageEvent = new MessageEvent();
    }

    /// <summary>
    /// Use this for initialization
    /// </summary>
    public void Start()
	{
        EventManager.AddNoArgumentInvoker(this);

        count = 0;

        timer = gameObject.AddComponent<Timer>();
        timer.Duration = 1f;
        timer.Run();
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
        if (timer.Finished)
        {
            InvokeNoArgumentEvent();
            count++;
            InvokeOneArgumentEvent(count);

            timer.Duration = 1;
            timer.Run();
        }
	}

    /// <summary>
    /// Adds the given listener to the no argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddNoArgumentListener(UnityAction listener)
    {
        messageEvent.AddListener(listener);
    }

    /// <summary>
    /// Adds the given listener to the one argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void AddOneArgumentListener(UnityAction<int> listener)
    {
        countMessageEvent.AddListener(listener);
    }

    /// <summary>
    /// Removes the given listener to the no argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void RemoveNoArgumentListener(UnityAction listener)
    {
        messageEvent.RemoveListener(listener);
    }

    /// <summary>
    /// Removes the given listener to the one argument event
    /// </summary>
    /// <param name="listener">listener</param>
    public void RemoveOneArgumentListener(UnityAction<int> listener)
    {
        countMessageEvent.RemoveListener(listener);
    }

    /// <summary>
    /// Invokes the no argument event
    /// 
    /// NOTE: We need this public method for the autograder to work
    /// </summary>
    public void InvokeNoArgumentEvent()
    {
        messageEvent.Invoke();
    }

    /// <summary>
    /// Invokes the one argument event
    /// 
    /// NOTE: We need this public method for the autograder to work
    /// </summary>
    /// <param name="argument">argument to use for the Invoke</param>
    public void InvokeOneArgumentEvent(int argument)
    { 
        countMessageEvent.Invoke(argument);
    }
}
