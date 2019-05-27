import { TestBed, inject } from '@angular/core/testing';

import { MatchesHubService } from './matches-hub.service';

describe('MatchesHubService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MatchesHubService]
    });
  });

  it('should be created', inject([MatchesHubService], (service: MatchesHubService) => {
    expect(service).toBeTruthy();
  }));
});
