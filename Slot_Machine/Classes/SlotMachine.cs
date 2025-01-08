using System.Linq;
using Exiled.API.Features.Toys;

namespace Slot_Machine.Classes;

public class SlotMachine {
    public Primitive[] Body = new Primitive[2];
    public Primitive[] Lever = new Primitive[3];
    public Primitive[] Wheels = new Primitive[12];
    public Light[] Lights = new Light[3];
    public int[] Index = new int[3];

    public SlotMachine(Primitive[] body, Light[] lights, int[] index) {
        Body = body.Where(x => body.IndexOf(x) < 2).ToArray();
        Lever = body.Where(x => body.IndexOf(x) < 5 && body.IndexOf(x) > 1).ToArray();
        Wheels = body.Where(x => body.IndexOf(x) > 4).ToArray();
        Lights = lights;
        Index = index;
    }
}