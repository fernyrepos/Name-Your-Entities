using Verse;

namespace NameYourEntities
{
    public class Dialog_RenameEntity : Dialog_Rename
    {
        public Pawn pawn;
        public Dialog_RenameEntity(Pawn pawn)
        {
            this.pawn = pawn;
            this.curName = pawn.LabelCap;
        }

        protected override void SetName(string name)
        {
            pawn.Name = new NameSingle(name);
        }
    }
}
