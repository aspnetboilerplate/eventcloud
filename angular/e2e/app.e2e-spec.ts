import { EventCloudTemplatePage } from './app.po';

describe('EventCloud App', function() {
  let page: EventCloudTemplatePage;

  beforeEach(() => {
    page = new EventCloudTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
