using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Container : MonoBehaviour {

    [System.Serializable]
    public class ContainerItem
    {
        public System.Guid Id; //system.guid is a 16 byte random identifier,
        //the percentage of 2 system.guid being same is near to 0 
        //so we can say it is unique
        public string Name;
        public int Maximum;
        public int Remaining
        {
            get
            {
                return Maximum - amountTaken;
            }
        }
        private int amountTaken;
        //methods:
        public int Get(int value)
        {
            if (value + amountTaken > Maximum)
            {
                int tooMuch = amountTaken + value - Maximum;
                amountTaken = Maximum;
                return value - tooMuch;
            }
            amountTaken += value;
            return value;
        }
        //contrustor:
        public ContainerItem()
        {
            Id = System.Guid.NewGuid(); //make a random system.guid and assign it to id
        }
    }

    public List<ContainerItem> items;
    public event System.Action OnContainerReady;

    void Awake()
    {
        items = new List<ContainerItem>();
        if (OnContainerReady != null)
            OnContainerReady();
    }
    
    public System.Guid add(string name, int maximum)
    {
        items.Add(new ContainerItem{
            Name = name,
            Maximum = maximum
        });
        return items.Last().Id;
    }

    public int TakeFromContainer(System.Guid id, int amount)
    {
        var containerItem = items.Where(x => x.Id == id).FirstOrDefault();
        if(containerItem == null)
            return -1;
        return containerItem.Get(amount);

    }
}
