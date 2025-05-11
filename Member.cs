public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public List<int> BorrowedBookIds { get; set; }

    public Member(int id, string name)
    {
        MemberId = id;
        Name = name;
        BorrowedBookIds = new List<int>();
    }
}