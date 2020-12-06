export class ActorModel{
    public Id: number;
    public Name: string;
    public Surname: string;
    public Fathername: string;
    public Country: string;
    public CountFilms: number;
    public Description: string;
    public BirthYear: number;
    public Age: number;
    public PictureUrl: string;

    construstor(){
        this.Id = null;
        this.Name = null;
        this.Surname = null;
        this.Fathername = null;
        this.Country = null;
        this.CountFilms = null;
        this.Description = null;
        this.BirthYear = null;
        this.Age = null;
        this.PictureUrl = null;
    }
}