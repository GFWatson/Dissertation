using UnityEngine;
using System.Collections;

public class animalController : MonoBehaviour {

    public int price, wCost, wGain, hRate, cRate, tRate;
    float moveX;
    float moveY;
    Vector3 averagePos;
    int current;
    public GameObject ani;
    public string aniTag;
    public funds scriptB;
    public microFunds scriptA;
    public score scriptC, scriptT, scriptH;
    public notifications scriptX, scriptY;
    bool owned;
    public AudioClip tap;

    // Use this for initialization
    void Start () {
        moveX = 0.5f;
        moveY = 0.5f;
        current = 0;
        /*
        GameObject b = GameObject.Find("Funds");
        scriptB = b.GetComponent<funds>();
        GameObject a = GameObject.Find("MicroFunds");
        scriptA = a.GetComponent<microFunds>();
        GameObject c = GameObject.Find("cScore");
        scriptC = c.GetComponent<score>();
        GameObject t = GameObject.Find("tScore");
        scriptT = t.GetComponent<score>();
        GameObject h = GameObject.Find("hScore");
        scriptH = h.GetComponent<score>();
        */
        float rdm1 = Random.Range(-2.0f, 2.0f);
        float rdm2 = Random.Range(-2.0f, 2.0f);
        averagePos = new Vector3(rdm1, rdm2, 0.0f);
        owned = false;        
    }
	
	// Update is called once per frame
	void Update () {
        current++;
        if (current == 100) {
            moveX = Random.Range(-1.0f, 1.0f);
            moveY = Random.Range(-1.0f, 1.0f);
            current = 0;
        }
	}

    public void create() {
        //instantiate animal
        Instantiate(ani, averagePos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        scriptB.change(-price);
        scriptB.changeWeeklyCost(wCost);
        scriptB.changeWeeklyGain(wGain);
        scriptC.change(cRate);
        scriptT.change(tRate);
        scriptH.change(hRate);
        
        scriptX.changeText("You have bought a " + aniTag + "!");
        scriptX.makeVis();
        
        if (!owned)
        {
            InvokeRepeating("calcAvPos", 0.0f, 120.0f);
            owned = true;
            animalInfo();
        }

        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void rescueCreate()
    {
        Instantiate(ani, averagePos, new Quaternion(0.0f, 0.0f, 0.0f, 0.0f));
        scriptB.changeWeeklyCost(wCost);
        scriptB.changeWeeklyGain(wGain);
        scriptC.change(cRate);
        scriptT.change(tRate);
        scriptH.change(hRate);

        scriptX.changeText("You have rescued a " + aniTag + "!");
        scriptX.makeVis();

        if (!owned)
        {
            InvokeRepeating("calcAvPos", 0.0f, 120.0f);
            owned = true;
        }

        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void microCreate()
    {
        Instantiate(ani, new Vector3(0.0f, 0.0f, -1.0f), new Quaternion( 0.0f, 0.0f, 0.0f, 0.0f));
        scriptA.change(-25);
        scriptB.changeWeeklyCost(wCost);
        scriptB.changeWeeklyGain(wGain);
        scriptC.change(cRate);
        scriptT.change(tRate);
        scriptH.change(hRate);

        scriptX.changeText("You have bought a " + aniTag + "!");
        scriptX.makeVis();

        if (!owned)
        {
            InvokeRepeating("calcAvPos", 0.0f, 120.0f);
            owned = true;
            animalInfo();
        }

        AudioSource source = GetComponent<AudioSource>();
        source.PlayOneShot(tap, 0.7f);
    }

    public void rem()
    {
        //for some reason using the already defined scripts causes errors
        //no one could find the reason why
        //so just reset into locals here
        GameObject b = GameObject.Find("Funds");
        funds scriptB = b.GetComponent<funds>();
        GameObject a = GameObject.Find("MicroFunds");
        microFunds scriptA = a.GetComponent<microFunds>();
        GameObject c = GameObject.Find("cScore");
        score scriptC = c.GetComponent<score>();
        GameObject t = GameObject.Find("tScore");
        score scriptT = t.GetComponent<score>();
        GameObject h = GameObject.Find("hScore");
        score scriptH = h.GetComponent<score>();
        
        scriptB.changeWeeklyCost(-wCost);
        scriptB.changeWeeklyGain(-wGain);
        scriptC.change(-cRate);
        scriptT.change(-tRate);
        scriptH.change(-hRate);

        scriptX.changeText("Your" + aniTag + " has just died.");
        scriptX.makeVis();
        
    }

    public float getX() {
        return moveX;
    }

    public float getY() {
        return moveY;
    }

    void calcAvPos()
    {
        float x = 0.0f;
        float y = 0.0f;
        int num = 0;
        GameObject[] allAnimals = GameObject.FindGameObjectsWithTag(aniTag);
        if (allAnimals.Length != 0)
        {
            foreach (GameObject a in GameObject.FindGameObjectsWithTag(aniTag))
            {
                num++;
                Vector3 vec3 = a.transform.position;
                x += vec3.x;
                y += vec3.y;
            }

            averagePos.x = x / num;
            averagePos.y = y / num;
            averagePos.z = 0.0f;
        }
        else
        {
            averagePos.x = 0.19f;
            averagePos.y = 0.04f;
        }
    }

    void animalInfo()
    {
        if(aniTag == "baboon")
        {
            scriptY.changeText("A chacma baboon is the largest of all baboons and one of the largest monkeys found in the world. While the species is not yet threatened the increasing human population means contact has also increased. They are now often hunted and trapped, reducing their numbers.");
            scriptY.makeVis();
        }
        if (aniTag == "black rhino")
        {
            scriptY.changeText("Black rhinos are native to south and eastern Africa. They are critically endangered, and often killed for their horns which is worth $65,000/kilogram. Three subspecies, including western black rhinos, were declared extinct by IUCN in 2011.");
            scriptY.makeVis();
        }
        if (aniTag == "buffalo")
        {
            scriptY.changeText("The African Buffalo has never been domesticated, unlike many other species of buffalo found around the world. It is considered one of the \"big five\" and is a highly sought-after trophy in hunting.");
            scriptY.makeVis();
        }
        if (aniTag == "bushbaby")
        {
            scriptY.changeText("Galagos, otherwise known as bushbabies, are nocturnal primates known for their large eyes. It is believed the name bushbaby comes from the species' distinct cries. They are the most successful primates in Africa.");
            scriptY.makeVis();
        }
        if (aniTag == "cape hare")
        {
            scriptY.changeText("Cape Hare's are nocturnal herbivores. Like other hares they are very fast, in fact the only predator capable of outrunning them is the cheetah.");
            scriptY.makeVis();
        }
        if (aniTag == "caracal")
        {
            scriptY.changeText("Caracals are medium-sized wild cats, known for their religious significance in ancient Egypt. They are often killed by farmers who see them as a nuisance to wildstock and are considered rare. It is believed that soon the conservation status of the species will worsen.");
            scriptY.makeVis();
        }
        if (aniTag == "cheetah")
        {
            scriptY.changeText("The Cheetah is the fastest land animal in the world, reaching speeds of 75mph. It is currently listed as vulnerable, due to habitat loss and the illegal pet trade. They are a charismatic species so are often used as \"ambassadors\" for wildlife conservation.");
            scriptY.makeVis();
        }
        if (aniTag == "elephant")
        {
            scriptY.changeText("Elephants are highly intelligent and form close family units. Between 1980 and 1990 their population was more than halved. They are often killed for their ivory or for their grazing land. Hardly surprising when in the last 25 years the wholesale price of ivory in China has risen from $5 to $2,100. This means 35,000 - 50,000 elephants are paoched each year.");
            scriptY.makeVis();
        }
        if (aniTag == "giraffe")
        {
            scriptY.changeText("Rothschild's Giraffe is one of the top ten most endangered subspecies in Africa. Only a few hundred remain in the wild. It is easily distinguishable from the other subspecies of giraffe due to its distinctive coat.");
            scriptY.makeVis();
        }
        if (aniTag == "hippo")
        {
            scriptY.changeText("Hippopotamuses are the third largest land mammal in the world, and their closest living relatives are actually whales and porpoises. They were declared vulnerable in 2006 when their population was estimated to be between 125,000 and 150,000.");
            scriptY.makeVis();
        }
        if (aniTag == "honey badger")
        {
            scriptY.changeText("Honey Badgers are highly intelligent animals and one of the few known to be capable of using tools. They are well known for their fierce nature.");
            scriptY.makeVis();
        }
        if (aniTag == "impala")
        {
            scriptY.changeText("Impalas are a medium-sized antelope found in Africa. They are very important to the ecosystem as they are important prey for numerous species.");
            scriptY.makeVis();
        }
        if (aniTag == "leopard")
        {
            scriptY.changeText("Leopards are one of the five \"big cats\" and is known for its ability to haul its prey into tress. They are threatened by habitat loss and illegal hunting in their habitats, and their pelts are can be sold in the illegal wildlife trade.");
            scriptY.makeVis();
        }
        if (aniTag == "lion")
        {
            scriptY.changeText("The Lion is the second-largest cat after the tiger. The males have distinctive mane and they are unusually social compared to other cats, living in large prides. Lions are classed as vulnerable due to habitat loss and conflicts with humans.");
            scriptY.makeVis();
        }
        if (aniTag == "meerkat")
        {
            scriptY.changeText("Meerkats are small mammals belonging to the mongoose family. They live in large \"mobs\" or \"gangs\" and are very social animals. They have become quite popular in western cultures and are a favourite with tourists.");
            scriptY.makeVis();
        }
        if (aniTag == "penguin")
        {
            scriptY.changeText("The African Penguin is an endangered because of commercial fishing and climate change effecting their prey. They have also been the victim of numerous oil spills. They are very popular with tourists.");
            scriptY.makeVis();
        }
        if (aniTag == "porcupine")
        {
            scriptY.changeText("Porcupines are rodents with distinctive spines, or quills, that protect them from predators. They are nocturnal, and have monogamous mating relationships.");
            scriptY.makeVis();
        }
        if (aniTag == "riverine rabbit")
        {
            scriptY.changeText("The Riverine Rabbit is one of the most endangered mammals in the world, and the most endangered in Africa. There are only around 250 living adults. They have a very small habitat, only found in a few places in the Karoo Desert near river basins.");
            scriptY.makeVis();
        }
        if (aniTag == "rock hyrax")
        {
            scriptY.changeText("Rock Hyraxes are small mammals similair in appearance to guinea pigs and other large rodents. They are not currently endangered.");
            scriptY.makeVis();
        }
        if (aniTag == "spotted hyena")
        {
            scriptY.changeText("The Spotted Hyena is the most common large carnivore in Africa. This is mainly due to its adaptability and opportunism. It is often viewed negatively in most cultures, despite its complex social structures that are similiar to primates.");
            scriptY.makeVis();
        }
        if (aniTag == "springbok")
        {
            scriptY.changeText("The Springbok is a medium-sied antelope that have long horns. They are actually one of the few antelope species that have an expanding population and are classified as Least Concern by the IUCN.");
            scriptY.makeVis();
        }
        if (aniTag == "warthog")
        {
            scriptY.changeText("Common Warthogs are a wild member of the pig family. They are often confused with Bushpigs, only distinguishable by their warts. No sub-species of warthog is currently endangered, though the Cape Warthog was declared extinct in 1871.");
            scriptY.makeVis();
        }
        if (aniTag == "wildcat")
        {
            scriptY.changeText("African Wildcats are similiar in size and appearance to domestic cats. They are not currently endangered but there are fears of genetic pollution caused by breeding with domestic cats.");
            scriptY.makeVis();
        }
        if (aniTag == "wild dog")
        {
            scriptY.changeText("African Wild Dogs are one of the most endangered species in Africa, with ~6,600 adults left and only 1,400 of them fully grown. They are suffering badly from human persecution and disease.");
            scriptY.makeVis();
        }
        if (aniTag == "wildebeast")
        {
            scriptY.changeText("Wildebeast are a genus of antelope and closely related to cattle, sheep etc. They are quite a tourist attraction as their seasonal migration is quite the spectacle. They are not currently endangered.");
            scriptY.makeVis();
        }
        if (aniTag == "white lion")
        {
            scriptY.changeText("White Lions are not a different species to African Lions, they simply have a rare colour mutation. Their population is almost exclusively in zoos, as it was not until recently that people believed they could survive in the wild. Their white colour is caused by a recessive gene so is difficult to breed.");
            scriptY.makeVis();
        }
        if (aniTag == "white rhino")
        {
            scriptY.changeText("White Rhinos have two sub-species, the Southern White Rhino with an estimated population of 20,000, and the Northen White Rhino. The Northen has only three confirmed individuals alive, all of which are in captivity. They are poached for their horns which are ground down and sold on for traditional medicines, which means it is worth more than its weight in gold. Mozambique, one of the four main countries that White Rhinos occupy, classes the poaching of them as a misdemeanor.");
            scriptY.makeVis();
        }
        if (aniTag == "zebra")
        {
            scriptY.changeText("Grevy's Zebra, also known as the imperial zebra, is the largest species of zebra and also the most threatened. In fact, it is one of the most endangered species in Africa. In recent years however, their population has stabilised thanks to conservation efforts.");
            scriptY.makeVis();
        }
    }
}
