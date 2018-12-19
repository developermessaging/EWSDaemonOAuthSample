/*
 * By David Barrett, Microsoft Ltd. 2018 Use at your own risk.  No warranties are given.
 * 
 * DISCLAIMER:
 * THIS CODE IS SAMPLE CODE. THESE SAMPLES ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND.
 * MICROSOFT FURTHER DISCLAIMS ALL IMPLIED WARRANTIES INCLUDING WITHOUT LIMITATION ANY IMPLIED WARRANTIES OF MERCHANTABILITY OR OF FITNESS FOR
 * A PARTICULAR PURPOSE. THE ENTIRE RISK ARISING OUT OF THE USE OR PERFORMANCE OF THE SAMPLES REMAINS WITH YOU. IN NO EVENT SHALL
 * MICROSOFT OR ITS SUPPLIERS BE LIABLE FOR ANY DAMAGES WHATSOEVER (INCLUDING, WITHOUT LIMITATION, DAMAGES FOR LOSS OF BUSINESS PROFITS,
 * BUSINESS INTERRUPTION, LOSS OF BUSINESS INFORMATION, OR OTHER PECUNIARY LOSS) ARISING OUT OF THE USE OF OR INABILITY TO USE THE
 * SAMPLES, EVEN IF MICROSOFT HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES. BECAUSE SOME STATES DO NOT ALLOW THE EXCLUSION OR LIMITATION
 * OF LIABILITY FOR CONSEQUENTIAL OR INCIDENTAL DAMAGES, THE ABOVE LIMITATION MAY NOT APPLY TO YOU.
 * */
 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Exchange.WebServices.Data;
using System.Windows.Forms;

namespace EWSDaemonOAuthSample
{
    class EWSTracer : ITraceListener, IDisposable
    {
        TextBox _outputTextbox = null;
        ListBox _outputListBox = null;

        public EWSTracer(TextBox OutputTextBox)
        {
            _outputTextbox = OutputTextBox;
        }

        public EWSTracer(ListBox OutputListBox)
        {
            _outputListBox = OutputListBox;
        }

        public void Dispose()
        {
        }

        public void Trace(string traceType, string traceMessage)
        {
            if ( (_outputTextbox == null) && (_outputListBox==null) )
                return;

            lock (this)
            {
                if (_outputTextbox != null)
                {
                    try
                    {
                        if (_outputTextbox.InvokeRequired)
                        {
                            _outputTextbox.Invoke(new MethodInvoker(delegate ()
                            {
                                _outputTextbox.Text += "/r/n" + traceMessage;
                                _outputTextbox.Refresh();
                            }));
                        }
                        else
                        {
                            _outputTextbox.Text += "/r/n" + traceMessage;
                            _outputTextbox.Refresh();
                        }
                    }
                    catch { }
                }

                if (_outputListBox != null)
                {
                    try
                    {
                        if (_outputListBox.InvokeRequired)
                        {
                            _outputListBox.Invoke(new MethodInvoker(delegate ()
                            {
                                _outputListBox.Items.Add(traceMessage);
                                _outputTextbox.Refresh();
                            }));
                        }
                        else
                        {
                            _outputListBox.Items.Add(traceMessage);
                            _outputTextbox.Refresh();
                        }
                    }
                    catch { }
                }
            }
        }

    }
}
