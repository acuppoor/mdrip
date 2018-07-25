/*
 * Author: Abdullah A Almsaeed
 * Date: 4 Jan 2014
 * Description:
 *      This is a demo file used only for the main dashboard (index.html)
 **/

$(function () {
    Morris.Area({
      element: 'graph',
      behaveLikeLine: true,
      data: [
        {x: '2011 Q1', y: 3, z: 3},
        {x: '2011 Q2', y: 2, z: 1},
        {x: '2011 Q3', y: 2, z: 4},
        {x: '2011 Q4', y: 3, z: 3}
      ],
      xkey: 'x',
      ykeys: ['y', 'z'],
      labels: ['Y', 'Z']
    });
  
});
