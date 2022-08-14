using CarLombards.Interfaces;

namespace CarLombards.Services;

public class PagesOptions : IPagesOptions
{
    public string TagsHeadEntityTitle => "TagsHead";

    public string TagsBodyEntityTitle => "TagsBody";

    public string EmptyEntityViewTitle => "None";
}