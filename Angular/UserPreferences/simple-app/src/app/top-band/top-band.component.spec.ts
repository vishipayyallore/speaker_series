import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TopBandComponent } from './top-band.component';

describe('TopBandComponent', () => {
  let component: TopBandComponent;
  let fixture: ComponentFixture<TopBandComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TopBandComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TopBandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
