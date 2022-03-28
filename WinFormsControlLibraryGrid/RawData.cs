using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsControlLibraryGrid
{
    internal class RawData
    {
		
		DateTime _mesureDtTm;
		String _LotId;
		int _waferNo;
		float _actVal;
		float _predVal;
		float _accuracy;

		public RawData()
        {

        }

		public RawData(DateTime mesureDtTm, String LotId, int waferNo,
					 float actVal, float predVal, float accuracy)
		{
			_mesureDtTm = mesureDtTm;
			_LotId = LotId;
			_waferNo = waferNo;
			_actVal = actVal;
			_predVal = predVal;
			_accuracy = accuracy;
		}

		public DateTime mesureDtTm { get; set; }
		public String LotId { get; set; }
		public int waferNo { get; set; }
		public float actVal { get; set; }
		public float predVal { get; set; }
		public float accuracy { get; set; }




	}
}
