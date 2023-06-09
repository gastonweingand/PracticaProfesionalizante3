///////////////////////////////////////////////////////////
//  IInvestor.cs
//  Implementation of the Class IInvestor
//  Generated by Enterprise Architect
//  Created on:      05-jun.-2023 19:31:59
//  Original author: gasto
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace Observador {
	/// <summary>
	/// This class defines an updating interface for objects that should be notified of
	/// changes in a subject.
	/// </summary>
	public interface IInvestor {

		void Update(Stock stock);

	}//end IInvestor

}//end namespace Observador