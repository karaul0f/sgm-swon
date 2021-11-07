public class ReviewListController : ListController
{
    // Start is called before the first frame update
    protected sealed override void Start()
    {
        base.Start();
    }

    public override void UpdateItems()
    {
        ClearAll();

        if (m_tourManagerScript.TourConfigurator.AvailableCounties == null)
            return;

        foreach (var country in m_tourManagerScript.TourConfigurator.AvailableCounties)
        {

            CreateElement(country.Name, country == m_tourManagerScript.TourConfigurator.SelectedCountry);
        }
    }
}
