namespace course.Controllers
{
    public class temp_delete
    {
        void deleteMe()
        {
            Random r = new Random(6543);
            for (int i = 0; i < 5; i++)
                Console.WriteLine(r.Next());
        }
    }
}
